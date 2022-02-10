import pandas as pd
import numpy as np

import joblib

#Funktion für RMSE erstellen
from keras import backend as K
def root_mean_squared_error(y_true, y_pred):
    return K.sqrt(K.mean(K.square(y_pred - y_true)))

import warnings
warnings.filterwarnings("ignore")

#Skalierte Daten für Modellierung laden
df_scaled = pd.read_csv("model_data/data_scaled.csv", index_col=0, parse_dates=True)
df_scaled.index.freq = "D"

#Aufteilung X (Merkmale) und y (Ziel)
X = df_scaled[["verbrauch","arbeitstag","temperatur","tagesstunden"]]
#Stromverbrauch wird bei X um eine Stelle nach vorne verschoben, daher entfällt der 01.01.2015
X["arbeitstag"] = X["arbeitstag"].shift(-1)
X["temperatur"] = X["temperatur"].shift(-1)
X["tagesstunden"] = X["tagesstunden"].shift(-1)
X = X[-14:]

#Exogene Daten für nächsten Tag laden und skalieren
df_exog_next_day = pd.read_csv("api_data/exog_next_day.csv")

scaler_exog = joblib.load("model_data/scaler_exog.save")
exog_next_day_scaled = scaler_exog.transform(df_exog_next_day)

#Wettervorhersage in Zeitfenster einfügen
X["arbeitstag"] = X["arbeitstag"].fillna(exog_next_day_scaled[0][0])
X["temperatur"] = X["temperatur"].fillna(exog_next_day_scaled[0][1])
X["tagesstunden"] = X["tagesstunden"].fillna(exog_next_day_scaled[0][2])

X_prediction = X.values.reshape(1,14,4)

#Modell laden
from tensorflow.keras.models import load_model
model = load_model("model_data/LSTM.h5", custom_objects={"root_mean_squared_error":root_mean_squared_error})

#Vorhersage erstellen und invers-skalieren
prediction_scaled = model.predict(X_prediction)

scaler_endog = joblib.load("model_data/scaler_endog.save")
prediction = scaler_endog.inverse_transform(prediction_scaled)

print(int(prediction[0][0]))