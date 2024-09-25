import cv2, dlib

img = cv2.imread("img/picture.jpg")
img = cv2.resize(img, (700, 540), interpolation=cv2.INTER_AREA)

cv2.putText(img, 'rotate', (50,120), cv2.FONT_HERSHEY_SIMPLEX, 1, (250,80,50), 3)
cv2.putText(img, 'Chinikaylo', (50,160), cv2.FONT_HERSHEY_SIMPLEX, 1, (250,80,50), 3)

rotated_image = cv2.rotate(img, cv2.ROTATE_90_CLOCKWISE)

cv2.imshow("rotated ship", rotated_image)

sobel_x = cv2.Sobel(img, cv2.CV_64F, 1, 0, ksize=5)
sobel_y = cv2.Sobel(img, cv2.CV_64F, 0, 1, ksize=5)

gradient_magnitude = cv2.magnitude(sobel_x, sobel_y)
gradient_magnitude = cv2.convertScaleAbs(gradient_magnitude)

cv2.imshow("gradient_magnitude", gradient_magnitude)



# gray_image = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
#
# grad_x = cv2.Sobel(gray_image, cv2.CV_64F, 1, 0, ksize=5)
# grad_y = cv2.Sobel(gray_image, cv2.CV_64F, 0, 1, ksize=5)
#
# abs_grad_x = cv2.convertScaleAbs(grad_x)
# abs_grad_y = cv2.convertScaleAbs(grad_y)
#
# # Объединяем градиенты по X и Y
# relief_image = cv2.addWeighted(abs_grad_x, 0.5, abs_grad_y, 0.5, 0)
#
# # cv2.imshow("gradient_magnitude", relief_image)



cv2.waitKey()
