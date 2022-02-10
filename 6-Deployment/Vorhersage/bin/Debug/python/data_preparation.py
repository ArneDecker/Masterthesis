import pandas as pd
pd.set_option('display.expand_frame_repr', False)

from sklearn.preprocessing import MinMaxScaler
import joblib

#Feature Selection####################################################################################################################################

#Daten aus CSV-Datei laden
df = pd.read_csv("input_data/verbrauch.csv", index_col=0, usecols=[0, 1, 5], parse_dates=True)
df.index.freq = "D"

#Temperatur hinzufügen
df_ = pd.read_csv("input_data/verbrauch.csv", index_col=0, usecols=[0], parse_dates=True)
df_ = df_.join(pd.read_csv("input_data/stuttgart.csv", index_col=0, parse_dates=True, usecols=[0,2], squeeze=True).rename("stuttgart"))
df_ = df_.join(pd.read_csv("input_data/freiburg.csv", index_col=0, parse_dates=True, usecols=[0,2], squeeze=True).rename("freiburg"))
df_ = df_.join(pd.read_csv("input_data/mannheim.csv", index_col=0, parse_dates=True, usecols=[0,2], squeeze=True).rename("mannheim"))
df_ = df_.join(pd.read_csv("input_data/ulm.csv", index_col=0, parse_dates=True, usecols=[0,2], squeeze=True).rename("ulm"))

df["temperatur"] = round(((df_["stuttgart"] + df_["freiburg"] + df_["mannheim"] + df_["ulm"]) / 4), 1)

#Sonnenauf-/Sonnenuntergang für Tagesstunden hinzufügen
df = df.join(pd.read_csv("input_data/stuttgart.csv", index_col=0, parse_dates=True, usecols=[0, 8, 9]))

#Feature Engineering##################################################################################################################################

#Tagesstunden berechnen
df["tagesstunden"] = round((pd.to_timedelta(
    pd.to_datetime(df["sonnenuntergang"]).dt.strftime("%H:%M:%S")).dt.total_seconds() - 
    pd.to_timedelta(pd.to_datetime(df["sonnenaufgang"]).dt.strftime("%H:%M:%S")).dt.total_seconds()) / 3600, 1)

#Sonnenaufgang und Sonnenuntergang werden durch Tagesstunden ersetzt
df.drop(["sonnenaufgang", "sonnenuntergang"], axis=1, inplace=True)

#Featurization########################################################################################################################################

#Merkmale sklaieren
exog = df[["arbeitstag", "temperatur", "tagesstunden"]]

scaler_exog = MinMaxScaler(feature_range=(0,1))
scaler_exog.fit(exog)

scaled_exog = pd.DataFrame(scaler_exog.transform(exog), columns=exog.columns, index=exog.index)

#Ziel skalieren
endog = df["verbrauch"]

scaler_endog = MinMaxScaler(feature_range=(0,1))
scaler_endog.fit(endog.values.reshape(-1,1))

scaled_endog = pd.DataFrame(scaler_endog.transform(endog.values.reshape(-1, 1)), columns=["verbrauch"], index=endog.index)

#Ziel und Merkmale zusammenführen
df_scaled = scaled_endog.join(scaled_exog)

#Daten speichern
df.to_csv("model_data/data.csv")
df_scaled.to_csv("model_data/data_scaled.csv")

#Skalierer speichern
joblib.dump(scaler_exog, "model_data/scaler_exog.save")
#scaler_exog = joblib.load("scaler_exog.save")

joblib.dump(scaler_endog, "model_data/scaler_endog.save")
#scaler_endog = joblib.load("scaler_endog.save")