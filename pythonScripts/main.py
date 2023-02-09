import cv2
from djitellopy import Tello

drop = Tello()

while True:
    frame = drop.get_frame_read()
    frame = frame.frame
    # print frame dimensions
    print(frame.shape)
    # save frame to file
    # flip frame
    frame = cv2.flip(frame, 0)
    cv2.imwrite("frame.jpg", frame)
