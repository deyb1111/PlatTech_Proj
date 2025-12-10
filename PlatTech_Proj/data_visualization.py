from utils_preprocess import load_clean_data
import matplotlib.pyplot as plt
import seaborn as sns
import os

df = load_clean_data()

os.makedirs("output", exist_ok=True)

# 1. Workload distribution
plt.figure(figsize=(7,5))
sns.countplot(x=df["WorkloadLabel"], palette="viridis")
plt.title("Workload Category Distribution")
plt.xlabel("Workload Level")
plt.ylabel("Count")
plt.savefig("output/workload_distribution.png")
plt.close()

# 2. Sleep Hours vs Workload (Boxplot)
plt.figure(figsize=(7,5))
sns.boxplot(x=df["WorkloadLabel"], y=df["SleepHours"], palette="coolwarm")
plt.title("Sleep Hours by Workload Level")
plt.savefig("output/sleep_vs_workload.png")
plt.close()

# 3. Study Hours vs Workload (Scatterplot)
plt.figure(figsize=(7,5))
sns.scatterplot(data=df, x="StudyHours", y="SleepHours",
                hue="WorkloadLabel", palette="deep")
plt.title("Study Hours vs Sleep Hours (Colored by Workload)")
plt.savefig("output/study_vs_sleep.png")
plt.close()

print("✔ Visualization images saved in /output/")