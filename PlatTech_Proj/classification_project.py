import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import LabelEncoder
from sklearn.metrics import classification_report, confusion_matrix
from sklearn.ensemble import RandomForestClassifier
import matplotlib.pyplot as plt
import seaborn as sns
import os

from utils_preprocess import load_clean_data

df = load_clean_data()

X = df[["SleepHours", "StudyHours", "Subjects", "LessThan5Nights"]]
y = df["WorkloadLabel"]

le = LabelEncoder()
y_encoded = le.fit_transform(y)

X_train, X_test, y_train, y_test = train_test_split(
    X, y_encoded, test_size=0.2, random_state=42
)

model = RandomForestClassifier()
model.fit(X_train, y_train)

y_pred = model.predict(X_test)

all_labels = le.transform(le.classes_)

print("\n=== CLASSIFICATION REPORT ===")
print(classification_report(
    y_test, y_pred,
    labels=all_labels,
    target_names=le.classes_,
    zero_division=0
))

os.makedirs("output", exist_ok=True)

cm = confusion_matrix(y_test, y_pred, labels=all_labels)

plt.figure(figsize=(7,6))
sns.heatmap(cm, annot=True, fmt="d", cmap="Blues",
            xticklabels=le.classes_, yticklabels=le.classes_)
plt.title("Confusion Matrix")
plt.savefig("output/confusion_matrix.png")
plt.close()

print("✔ ML classification completed. Output saved.")
