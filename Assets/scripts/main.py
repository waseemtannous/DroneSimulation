import tello
import cv2


# Create a tello object
drone = tello.Tello()
drone.connect()

drone.streamon()

def get_frame_data(frame):
    frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGBA)
    return frame.tobytes()


while True:
    frame_read = drone.get_frame_read()
    frame = frame_read.frame
    update_frame(frame)