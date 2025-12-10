from utils_preprocess import load_clean_data
import os

df = load_clean_data()

# Compute summary
summary = df.describe(include="all").to_string()

os.makedirs("output", exist_ok=True)

with open("output/summary.txt", "w", encoding="utf-8") as f:
    f.write("=== DATA SUMMARY ===\n\n")
    f.write(summary)

print("Summary saved to output/summary.txt")
