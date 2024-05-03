#include <iostream>
#include <vector>
#include <ctime>
#include <chrono>
#include <random>
#include <fstream>
#include <thread>
#include <omp.h>

using namespace std;
/*
point 11935: 29.3421    0: 85.0534      1: 70.6225
point 11939: 26.2351    0: 34.8971      1: 34.5825
point 11947: 11.5194    0: 66.5014      1: 63.2857
point 11950: 18.6245    0: 71.7392      1: 54.7617
point 11954: 13.6634    0: 46.4948      1: 58.1021
point 11957: 30.4422    0: 34.099       1: 62.9192
point 11965: 10.9743    0: 46.5361      1: 44.6704
point 11967: 23.1026    0: 59.8939      1: 74.4508
point 11968: 39.0781    0: 47.0191      1: 79.3236
point 11974: 7.85771    0: 48.1735      1: 51.9069
point 11977: 8.5412     0: 64.276       1: 59.2984
point 11979: 13.5371    0: 69.2615      1: 62.7285
point 11981: 21.8988    0: 53.4978      1: 70.4696
point 11983: 35.4312    0: 77.8759      1: 44.0397
point 11984: 17.7162    0: 73.5204      1: 63.6284
point 11988: 34.0323    0: 89.5212      1: 79.7543
point 11990: 27.5465    0: 54.6862      1: 75.4174
point 11992: 27.9636    0: 64.6247      1: 34.471
point 11998: 26.7951    0: 78.5235      1: 55.9321

point 11935: 29.3421    0: 85.0534      1: 70.6225
point 11939: 26.2351    0: 34.8971      1: 34.5825
point 11947: 11.5194    0: 66.5014      1: 63.2857
point 11950: 18.6245    0: 71.7392      1: 54.7617
point 11954: 13.6634    0: 46.4948      1: 58.1021
point 11957: 30.4422    0: 34.099       1: 62.9192
point 11965: 10.9743    0: 46.5361      1: 44.6704
point 11967: 23.1026    0: 59.8939      1: 74.4508
point 11968: 39.0781    0: 47.0191      1: 79.3236
point 11974: 7.85771    0: 48.1735      1: 51.9069
point 11977: 8.5412     0: 64.276       1: 59.2984
point 11979: 13.5371    0: 69.2615      1: 62.7285
point 11981: 21.8988    0: 53.4978      1: 70.4696
point 11983: 35.4312    0: 77.8759      1: 44.0397
point 11984: 17.7162    0: 73.5204      1: 63.6284
point 11988: 34.0323    0: 89.5212      1: 79.7543
point 11990: 27.5465    0: 54.6862      1: 75.4174
point 11992: 27.9636    0: 64.6247      1: 34.471
point 11998: 26.7951    0: 78.5235      1: 55.9321

*/

class Const {
public:
    static const int amountOfElements = 120000; //1200
    static const int numberOfElementAttributes = 5;//3
    static const int numberOfClusters = 6;//4
    static const int numberOfAttributesInOneIteration = 6000;
};

double calculateDistance(vector<double>& point1, vector<double>& point2) { // подсчет растояние между точками
    double distance = 0.0;
    for (int i = 0; i < Const::numberOfElementAttributes; i++) {
        distance += pow((point2[i] - point1[i]), 2);
    }
    return sqrt(distance);
}
void assignToClusterParaller(int k, vector<vector<double>>& points, vector<vector<double>>& centroids, vector<int>& clusterAssignments) {
    int start = k == 1 ? 0 : (k - 1) * Const::numberOfAttributesInOneIteration;
    int end = k * Const::numberOfAttributesInOneIteration;
    for (int i = start; i < end; i++) {
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
}

// присваиваем точки к кластеру
void assignToClusters(vector<vector<double>>& points, vector<vector<double>>& centroids, vector<int>& clusterAssignments) {
    vector<thread> threads;
    int countIteration = Const::amountOfElements / Const::numberOfAttributesInOneIteration;
    for (int k = 1; k <= countIteration; k++) {
        threads.emplace_back(assignToClusterParaller, k, ref(points),
            ref(centroids), ref(clusterAssignments));
        //thread thread_update(updateCentroidParaller, closestCentroid, ref(points), ref(centroids), ref(clusterAssignments));
    }
    for (auto& thread : threads) {
        thread.join();
    }
}
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
    //cout << i << endl;
    //cout << "time: " << e - s << endl;
}

// считаем новые координаты центроидов
void updateCentroids(vector<vector<double>>& points, vector<vector<double>>& centroids, vector<int>& clusterAssignments) {
    vector<thread> threads;
    for (int i = 0; i < Const::numberOfClusters; i++) {
        threads.emplace_back(updateCentroidParaller, i, &points,
            &centroids, &clusterAssignments);
    }
    for (auto& thread : threads) {
        thread.join();
    }
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
        // 
        //PrintIteration(count, points, centroids, clusterAssignments);
        // 
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

    this_thread::sleep_for(chrono::microseconds(60000));
}

/*
point 1170: 43.0104     0: 71.1913      1: 95.783       2: 75.3904
point 1182: 37.2204     0: 76.3864      1: 94.0976      2: 77.3905
point 1188: 26.6157     0: 70.5892      1: 83.6884      2: 64.6302
point 1194: 39.6203     0: 82.8722      1: 48.2622      2: 62.952
point 1198: 34.1926     0: 70.9455      1: 57.3965      2: 84.4468
point 1199: 22.936      0: 82.8165      1: 70.6646      2: 77.0968



*/





/*

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
        thread.detach();
    }
}
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
            ref(centroids), ref(clusterAssignments));
threads.emplace_back(updateCentroidParaller, i, &points,
    &centroids, &clusterAssignments);
    }
    for (auto& thread : threads) {
        thread.detach();
    }
}

*/