import cv2
from djitellopy import Tello

drone = Tello()

# drone.connect()
# drone.streamoff()
# drone.streamon()

while True:
    frame = drone.get_frame_read()
    frame = frame.frame

    # frame = cv2.flip(frame, 0)
    cv2.imwrite("frame.jpg", frame)
    print(drone.get_battery())
