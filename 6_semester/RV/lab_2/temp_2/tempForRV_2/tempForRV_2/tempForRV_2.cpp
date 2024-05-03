#include <iostream>
#include <vector>
#include <ctime>
#include <chrono>
#include <random>
#include <fstream>
#include <thread>
#include <omp.h>

using namespace std;

class Const {
public:
    static const int amountOfElements = 30; //1200
    static const int numberOfElementAttributes = 2;//3
    static const int numberOfClusters = 3;//4
};

double calculateDistance(vector<double>& point1, vector<double>& point2) { // подсчет растояние между точками
    double distance = 0.0;
    for (int i = 0; i < Const::numberOfElementAttributes; i++) {
        distance += pow((point2[i] - point1[i]), 2);
    }
    return sqrt(distance);
}
void assignToClusterParaller(int i, vector<vector<double>>& points, vector<vector<double>>& centroids, vector<int>& clusterAssignments) {
    double minDistance = numeric_limits<double>::max(); // берем значения что было с чем сравнивать
    int closestCentroid = -1;
    for (int j = 0; j < Const::numberOfClusters; j++) {
        double distance = calculateDistance(points[i], centroids[j]);// считаем
        if (distance < minDistance) { // если ближе запомнаем
            minDistance = distance;
            closestCentroid = j;
        }
    }
    clusterAssignments[i] = closestCentroid;
}

// присваиваем точки к кластеру
void assignToClusters(vector<vector<double>>& points, vector<vector<double>>& centroids, vector<int>& clusterAssignments) {
    vector<thread> threads;
    for (int i = 0; i < Const::amountOfElements; i++) {
        threads.emplace_back(assignToClusterParaller, i, ref(points),
            ref(centroids), ref(clusterAssignments));
        //thread thread_update(updateCentroidParaller, closestCentroid, ref(points), ref(centroids), ref(clusterAssignments));
    }
    for (auto& thread : threads) {
        thread.join();
    }
}
//void updateCentroidParaller(int i, vector<vector<double>>& points, vector<vector<double>>& centroids, vector<int>& clusterAssignments) {
void updateCentroidParaller(int i, vector<vector<double>>* points, vector<vector<double>>* centroids, vector<int>* clusterAssignments) {

    clock_t s = clock();
    vector<double> newCentroid(Const::numberOfElementAttributes);
    int count = 0;

    for (int j = 0; j < Const::amountOfElements; j++) {
        if ((*clusterAssignments)[j] == i) {
            for (int l = 0; l < Const::numberOfElementAttributes; l++) {
                newCentroid[l] += (*points)[j][l];
            }
            count++;
        }
    }
    if (count > 0) {
        for (int l = 0; l < Const::numberOfElementAttributes; l++) {
            newCentroid[l] /= count; // делим на количество точек в кластере
        }
        (*centroids)[i] = newCentroid;
    }
    clock_t e = clock();
    cout << i << endl;
    cout << "time: " << e - s << endl;
}

// считаем новые координаты центроидов
void updateCentroids(vector<vector<double>>& points, vector<vector<double>>& centroids, vector<int>& clusterAssignments) {
    vector<thread> threads;
    for (int i = 0; i < Const::numberOfClusters; i++) {
        /*threads.emplace_back(updateCentroidParaller, i, ref(points),
            ref(centroids), ref(clusterAssignments));*/
        threads.emplace_back(updateCentroidParaller, i, &points,
            &centroids, &clusterAssignments);
    }
    for (auto& thread : threads) {
        thread.join();
    }
}

void Do(vector<vector<double>>& points, vector<vector<double>>& centroids, vector<int>& clusterAssignments) {
    assignToClusters(points, centroids, clusterAssignments);
    updateCentroids(points, centroids, clusterAssignments);
}

void PrintIteration(int& count, vector<vector<double>>& points, vector<vector<double>>& centroids, vector<int>& clusterAssignments) {
    cout << "iteration " << count << endl;
    int countPoints = 0;
    for (int i = 0; i < Const::numberOfClusters; i++) {
        cout << "cluster " << i << ":" << endl;
        countPoints = 0;
        for (int j = 0; j < Const::amountOfElements; j++) {
            if (clusterAssignments[j] == i) {
                countPoints++;
                cout << "point " << j << ": ";
                cout << calculateDistance(points[j], centroids[i]) << "\t";
                for (int k = 0; k < Const::numberOfClusters; k++) {
                    if (k != i) {
                        cout << k << ": " << calculateDistance(points[j], centroids[k]) << "\t";
                    }
                }
                cout << endl;
            }
        }
        cout << "count points in cluster: " << countPoints << endl;
    }
    cout << "\n\n\n";
}

void kMeans(vector<vector<double>>& points, vector<vector<double>>& centroids, vector<double>& iterationTimes) {
    vector<int> OldclusterAssignments(Const::amountOfElements);
    int count = 0;
    while (true) {
        double s = clock();
        vector<int> clusterAssignments(Const::amountOfElements);
        ////thread thread_assignToClusters(assignToClusters, ref(points), ref(centroids), ref(clusterAssignments));
        assignToClusters(points, centroids, clusterAssignments);
        ////thread thread_updateCentroids(updateCentroids, ref(points), ref(centroids), ref(clusterAssignments));
        updateCentroids(points, centroids, clusterAssignments);

        double e = clock();
        iterationTimes.push_back((e - s) / CLOCKS_PER_SEC);
        //thread threadPrint(PrintIteration, ref(count), ref(points), ref(centroids), ref(clusterAssignments));
        //threadPrint.join();
        PrintIteration(count, points, centroids, clusterAssignments);
        //thread_assignToClusters.join();
        //thread_updateCentroids.join();
        if (clusterAssignments == OldclusterAssignments) { // если ничего не поменялось
            cout << "True" << count << endl;
            ofstream outFile("../../CountIteration.txt");//открываем файл
            if (outFile.is_open()) {
                outFile << count;
                outFile.close();//закрываем файл
            }
            else {
                cout << "Error, could not open file.";
            }
            break;
        }
        OldclusterAssignments = clusterAssignments;
        count++;

    }

}


int main() {

    vector<vector<double>> points(Const::amountOfElements, vector<double>(Const::numberOfElementAttributes));
    vector<vector<double>> centroids(Const::numberOfClusters, vector<double>(Const::numberOfElementAttributes));
    omp_set_num_threads(100);
    srand(0);
    vector<double> iterationTimes;
    for (int i = 0; i < Const::amountOfElements; i++) { // ставим рандомно точки
        for (int j = 0; j < Const::numberOfElementAttributes; j++) {
            points[i][j] = 1 + rand() % 100;
        }
    }
    for (int i = 0; i < Const::numberOfClusters; i++) { // так же рандомно кластеры
        for (int j = 0; j < Const::numberOfElementAttributes; j++) {
            centroids[i][j] = 1 + rand() % 100;
        }
    }
    double s = clock();//начало отсчета
    kMeans(points, centroids, iterationTimes);
    double e = clock();//конец отсчета
    cout << "K-Means Algorithm Execution Time: " << (e - s) / CLOCKS_PER_SEC << " s" << endl;//время выполнения
    ofstream outFile("../../IterationTimes.txt");//открываем файл
    if (outFile.is_open()) {
        for (int i = 0; i < iterationTimes.size(); i++) {//записываем в него
            outFile << iterationTimes[i] << " ";
        }
        outFile.close();//закрываем файл
    }
    else { // если не получилось открыть файл
        cout << "Error, could not open file.";
    }
    return 0;
}

/*
point 1170: 43.0104     0: 71.1913      1: 95.783       2: 75.3904
point 1182: 37.2204     0: 76.3864      1: 94.0976      2: 77.3905
point 1188: 26.6157     0: 70.5892      1: 83.6884      2: 64.6302
point 1194: 39.6203     0: 82.8722      1: 48.2622      2: 62.952
point 1198: 34.1926     0: 70.9455      1: 57.3965      2: 84.4468
point 1199: 22.936      0: 82.8165      1: 70.6646      2: 77.0968



*/