from glob import glob

import os, cv2, dlib

face_images = glob('img/faces.jpg')
if not os.path.exists('./output'):
    os.mkdir('./output')
detector = dlib.get_frontal_face_detector()
predictor = dlib.shape_predictor('shape_predictor_68_face_landmarks.dat')
for file in face_images:
    image = cv2.imread(file)

gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
rects = detector(gray, 1)
if len(rects) > 0:
    for rect in rects:
        shape = predictor(gray, rect)
        for i in range(0,68):
            cv2.circle(image, (shape.part(i).x, shape.part(i).y), 2, (100,100,100), -1)
            cv2.imwrite(f'./output/{os.path.split(file)[-1]}', image)
else:
    print('no faces detected')


cv2.waitKey()