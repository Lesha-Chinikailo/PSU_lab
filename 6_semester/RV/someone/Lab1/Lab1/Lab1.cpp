#include <iostream>
#include <vector>
#include <ctime>
#include <chrono>
#include <random>
#include <fstream>

void kMeansAlgorithm(std::vector<std::vector<double>>& points, std::vector<std::vector<double>>& centroids, std::vector<double>& iterationTimes);
double euclideanDistance(std::vector<double>& point1, std::vector<double>& point2);
void assignToClusters(std::vector<std::vector<double>>& points, std::vector<std::vector<double>>& centroids, std::vector<int>& clusterAssignments);
void updateCentroids(std::vector<std::vector<double>>& points, std::vector<std::vector<double>>& centroids, std::vector<int>& clusterAssignments);

int main() {
    setlocale(LC_ALL, "Russian");
    std::vector<std::vector<double>> points(30, std::vector<double>(2));
    std::vector<std::vector<double>> centroids(3, std::vector<double>(2));
    //std::vector<std::vector<std::vector<double>>> clustersContent(15);
    std::vector<double> iterationTimes;
    for (int i = 0; i < 30; i++) {
        for (int j = 0; j < 2; j++) {
            points[i][j] = 1 + rand() % 100;
        }
    }
    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 2; j++) {
            centroids[i][j] = 1 + rand() % 100;
        }
    }
    auto start = std::chrono::high_resolution_clock::now();
    kMeansAlgorithm(points, centroids, iterationTimes);
    auto end = std::chrono::high_resolution_clock::now();
    std::cout << "Время выполнения алгоритма K-средних: " << std::chrono::duration_cast<std::chrono::microseconds>(end - start).count() / 1e6 << " секунд" << std::endl; 
    std::ofstream outFile("E:/PSU_lab/6_semester/RV/someone/IterationTimes.txt"); 
    if (outFile.is_open()) {
        for (int i = 0; i < iterationTimes.size(); i++) {
            outFile << iterationTimes[i] << " ";
        }
        outFile.close(); 
    }
    else {
        std::cout << "Ошибка, не удалось открыть файл.\n";
    }
    return 0;
}

void kMeansAlgorithm(std::vector<std::vector<double>>& points, std::vector<std::vector<double>>& centroids, std::vector<double>& iterationTimes) {
    for (int i = 0; i < 5; i++) {
        auto start = std::chrono::high_resolution_clock::now();
        std::vector<int> clusterAssignments(30);
        assignToClusters(points, centroids, clusterAssignments);
        updateCentroids(points, centroids, clusterAssignments);
        auto end = std::chrono::high_resolution_clock::now();
        std::chrono::duration<double> duration = end - start;
        iterationTimes.push_back(duration.count());
    }
}

double euclideanDistance(std::vector<double>& point1, std::vector<double>& point2) {
    double distance = 0.0;
    for (int i = 0; i < 2; i++) {
        distance += pow((point1[i] - point2[i]), 2);
    }
    return sqrt(distance);
}

void assignToClusters(std::vector<std::vector<double>>& points, std::vector<std::vector<double>>& centroids, std::vector<int>& clusterAssignments) {
    for (int i = 0; i < 30; i++) {
        double minDistance = std::numeric_limits<double>::max();
        int closestCentroid = -1;
        for (int j = 0; j < 3; j++) {
            double distance = euclideanDistance(points[i], centroids[j]);
            if (distance < minDistance) {
                minDistance = distance;
                closestCentroid = j;
            }
        }
        clusterAssignments[i] = closestCentroid;
    }
}

void updateCentroids(std::vector<std::vector<double>>& points, std::vector<std::vector<double>>& centroids, std::vector<int>& clusterAssignments) {
    for (int i = 0; i < 3; i++) {
        std::vector<double> newCentroid(3);
        int count = 0;
        for (int j = 0; j < 30; j++) {
            if (clusterAssignments[j] == i) {
                for (int l = 0; l < 2; l++) {
                    newCentroid[l] += points[j][l];
                }
                count++;
            }
        }
        if (count > 0) {
            for (int l = 0; l < 2; l++) {
                newCentroid[l] /= count;
            }
            centroids[i] = newCentroid;
        }
    }
}