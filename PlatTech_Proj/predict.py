import sys
import numpy as np
from utils_preprocess import load_clean_data
from sklearn.preprocessing import LabelEncoder
from sklearn.ensemble import RandomForestClassifier

df = load_clean_data()

X = df[["SleepHours", "StudyHours", "Subjects", "LessThan5Nights"]]
y = df["WorkloadLabel"]

le = LabelEncoder()
y_encoded = le.fit_transform(y)

model = RandomForestClassifier()
model.fit(X, y_encoded)

sleep = float(sys.argv[1])
study = float(sys.argv[2])
subjects = float(sys.argv[3])
stress = float(sys.argv[4])

sample = np.array([[sleep, study, subjects, stress]])
prediction = model.predict(sample)

print(le.inverse_transform(prediction)[0])
