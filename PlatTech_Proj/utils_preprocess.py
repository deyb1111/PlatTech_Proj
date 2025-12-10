import pandas as pd
import numpy as np

def extract_average(val):
    """Convert ranges like '5-6' into numeric average."""
    if pd.isna(val):
        return None
    val = str(val).strip().replace("â€“", "-").replace("–", "-")
    parts = val.split("-")
    if len(parts) == 2:
        try:
            return (int(parts[0]) + int(parts[1])) / 2
        except:
            return None
    try:
        return float(parts[0])
    except:
        return None

def load_clean_data():
    df = pd.read_csv("Survery.csv")

    # Fix unicode dashes
    df = df.replace({"â€“": "-", "–": "-", "—": "-"}, regex=True)

    # Extract numeric features
    df["SleepHours"] = df["On average, how many hours of sleep do you get per night on weekdays?  "]\
        .str.extract(r"(\d+-?\d*)")[0].apply(extract_average)

    df["StudyHours"] = df["How many hours do you spend studying or doing academic work each day?  "]\
        .str.extract(r"(\d+-?\d*)")[0].apply(extract_average)

    df["Subjects"] = df["How many subjects are you currently enrolled in this semester?  "]\
        .str.extract(r"(\d+-?\d*)")[0].apply(extract_average)

    df["LessThan5Nights"] = df["How many nights per week do you sleep fewer than 5 hours due to academic work?  "]\
        .str.extract(r"(\d+-?\d*)")[0].apply(extract_average)

    # Extract workload (label)
    df["WorkloadLabel"] = df[
        "On a scale of 1 to 10, how would you rate your current academic workload?  "
    ].str.extract(r"\((.*?)\)", expand=False)

    # Drop incomplete rows
    df = df.dropna(subset=[
        "SleepHours", "StudyHours", "Subjects", "LessThan5Nights", "WorkloadLabel"
    ])

    return df