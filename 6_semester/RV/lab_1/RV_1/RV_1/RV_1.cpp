#include <iostream>
#include <vector>
#include <ctime>
#include <chrono>
#include <random>
#include <fstream>

using namespace std;

int amountOfElements = 30;
int numberOfElementAttributes = 2;
int numberOfClusters = 3;

double calculateDistance(vector<double>& point1, vector<double>& point2) { // подсчет растояние между точками
    double distance = 0.0;
    for (int i = 0; i < numberOfElementAttributes; i++) {
        distance += pow((point2[i] - point1[i]), 2);
    }
    return sqrt(distance);
}
// присваиваем точки к кластеру
void assignToClusters(vector<vector<double>>& points, vector<vector<double>>& centroids, vector<int>& clusterAssignments) {
    for (int i = 0; i < amountOfElements; i++) {
        double minDistance = numeric_limits<double>::max(); // берем значения что было с чем сравнивать
        int closestCentroid = -1;
        for (int j = 0; j < numberOfClusters; j++) {
            double distance = calculateDistance(points[i], centroids[j]);// считаем
            if (distance < minDistance) { // если ближе запомнаем
                minDistance = distance;
                closestCentroid = j;
            }
        }
        clusterAssignments[i] = closestCentroid;
    }
}
// считаем новые координаты центроидов
void updateCentroids(vector<vector<double>>& points, vector<vector<double>>& centroids, vector<int>& clusterAssignments) {
    for (int i = 0; i < numberOfClusters; i++) {
        vector<double> newCentroid(numberOfElementAttributes);
        int count = 0;
        for (int j = 0; j < amountOfElements; j++) {
            if (clusterAssignments[j] == i) {
                for (int l = 0; l < numberOfElementAttributes; l++) {
                    newCentroid[l] += points[j][l];
                }
                count++;
            }
        }
        if (count > 0) {
            for (int l = 0; l < numberOfElementAttributes; l++) {
                newCentroid[l] /= count; // делим на количество точек в кластере
            }
            centroids[i] = newCentroid;
        }
    }
}
void kMeans(vector<vector<double>>& points, vector<vector<double>>& centroids, vector<double>& iterationTimes) {
    vector<int> OldclusterAssignments(amountOfElements);
    int count = 0;
    while (true) {
        double s = clock();
        vector<int> clusterAssignments(amountOfElements);
        assignToClusters(points, centroids, clusterAssignments);
        updateCentroids(points, centroids, clusterAssignments);
        double e = clock();
        iterationTimes.push_back((e - s) / CLOCKS_PER_SEC);
        cout << "iteration " << count << endl;
        int countPoints = 0;
        for (int i = 0; i < numberOfClusters; i++) {
            cout << "cluster " << i << ":" << endl;
            countPoints = 0;
            for (int j = 0; j < amountOfElements; j++) {
                if (clusterAssignments[j] == i) {
                    countPoints++;
                    cout << "point " << j << ": ";
                    cout << calculateDistance(points[j], centroids[i]) << "\t";
                    for (int k = 0; k < numberOfClusters; k++) {
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

    vector<vector<double>> points(amountOfElements, vector<double>(numberOfElementAttributes));
    vector<vector<double>> centroids(numberOfClusters, vector<double>(numberOfElementAttributes));

    vector<double> iterationTimes;
    for (int i = 0; i < amountOfElements; i++) { // ставим рандомно точки
        for (int j = 0; j < numberOfElementAttributes; j++) {
            points[i][j] = 1 + rand() % 100;
        }
    }
    for (int i = 0; i < numberOfClusters; i++) { // так же рандомно кластеры
        for (int j = 0; j < numberOfElementAttributes; j++) {
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

