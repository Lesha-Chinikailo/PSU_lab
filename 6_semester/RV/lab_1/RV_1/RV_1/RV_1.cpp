#include <iostream>
#include <vector>
#include <cmath>

struct Point {
    double x;
    double y;
};

double calculateDistance(Point p1, Point p2) {
    return sqrt(pow((p1.x - p2.x), 2) + pow((p1.y - p2.y), 2));
}

int assignCluster(Point point, std::vector<Point>& centroids) {
    int cluster = 0;
    double minDistance = calculateDistance(point, centroids[0]);

    for (int i = 1; i < centroids.size(); i++) {
        double distance = calculateDistance(point, centroids[i]);
        if (distance < minDistance) {
            minDistance = distance;
            cluster = i;
        }
    }

    return cluster;
}

Point calculateCentroid(std::vector<Point>& points) {
    Point centroid = { 0, 0 };
    for (const auto& point : points) {
        centroid.x += point.x;
        centroid.y += point.y;
    }
    centroid.x /= points.size();
    centroid.y /= points.size();

    return centroid;
}

void kMeans(std::vector<Point>& data, int k) {
    std::vector<Point> centroids(k);

    // Initialize centroids randomly
    for (int i = 0; i < k; i++) {
        centroids[i] = data[rand() % data.size()];
    }

    std::vector<std::vector<Point>> clusters(k);

    bool converged = false;

    while (!converged) {
        // Assign points to clusters
        for (const auto& point : data) {
            int cluster = assignCluster(point, centroids);
            clusters[cluster].push_back(point);
        }

        // Update centroids
        converged = true;
        for (int i = 0; i < k; i++) {
            Point newCentroid = calculateCentroid(clusters[i]);
            if (newCentroid.x != centroids[i].x || newCentroid.y != centroids[i].y) {
                converged = false;
            }
            centroids[i] = newCentroid;
            clusters[i].clear();
        }
    }

    // Output final clusters and centroids
    for (int i = 0; i < k; i++) {
        std::cout << "Cluster " << i << ":\n";
        for (const auto& point : clusters[i]) {
            std::cout << "(" << point.x << ", " << point.y << ")\n";
        }
        std::cout << "Centroid: (" << centroids[i].x << ", " << centroids[i].y << ")\n\n";
    }
}

int main() {
    std::vector<Point> data = { {1, 2}, {2, 3}, {3, 4}, {5, 6}, {7, 8}, {8, 9} };
    int k = 2; // Number of clusters

    kMeans(data, k);

    return 0;
}
