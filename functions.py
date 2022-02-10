#CUSTOM_METRICS_ARIMA###################################################################################################################################################
def custom_metrics_arima(y_test_true, y_scaled_preds_test, statistics=True, plot=True, residuals=False, acfpacf=False):
    
    from sklearn import metrics
    import numpy as np
    
    import pandas as pd
    from collections import OrderedDict
    
    from sklearn.preprocessing import MinMaxScaler
    import joblib
    
    import matplotlib
    import matplotlib.pyplot as plt
    font = {'size'   : 20}
    matplotlib.rc('font', **font)
    
    from pylab import rcParams
    rcParams["figure.figsize"] = 30,16
    
    from statsmodels.graphics.tsaplots import plot_acf, plot_pacf
    
    scaler_target = joblib.load("../3-Data Preparation/scaler_endog.save")
    y_preds_test = pd.DataFrame(data=scaler_target.inverse_transform(y_scaled_preds_test.reshape(-1, 1)), columns=["vorhergesagt"], index=pd.date_range('01/01/2021', periods=365, freq='D')).squeeze()
    
    resids = y_test_true - y_preds_test
    
    if statistics == True:
        
        df_metrics = pd.DataFrame(index=["R2", "MAE", "MSE", "RMSE", "",  "MAPE"])
        
        df_metrics["Vorhersage"] = [
            round(metrics.r2_score(y_test_true, y_preds_test), 2),
            round(metrics.mean_absolute_error(y_test_true, y_preds_test), 0),
            round(metrics.mean_squared_error(y_test_true, y_preds_test), 0),
            round(np.sqrt(metrics.mean_squared_error(y_test_true, y_preds_test)), 0),
            "",
            "" + str(round(metrics.mean_absolute_percentage_error(y_test_true, y_preds_test)*100, 2)) + " %"
        ]
        
        print(df_metrics)
        
    if plot == True:
    
        for date in y_test_true[y_test_true.index.weekday == 0].index:

            plt.axvline(x=date, ymin=0, ymax=1, color="lightblue", linestyle="--", label="Wochenanfang")
        
        plt.plot(y_test_true, color="blue", label="Wahr");
        plt.plot(y_preds_test, color="green", label="Vorhergesagt");
        plt.title("Wahre und vorhersage Werte")
        plt.ylabel("Stromverbrauch in MWh")
        plt.ylim(100000,235000)
        
        #Legende einfügen
        handles, labels = plt.gca().get_legend_handles_labels()
        by_label = OrderedDict(zip(labels, handles))
        plt.legend(by_label.values(), by_label.keys(), loc="lower left", bbox_to_anchor=(0,-0.16), ncol=5)
        
        plt.show()
    
    if residuals == True:
        
        for date in y_test_true[y_test_true.index.weekday == 0].index:

            plt.axvline(x=date, ymin=0, ymax=1, color="lightblue", linestyle="--", label="Wochenanfang")
        
        y_upper_deviation = y_test_true * 0.022
        y_lower_deviation = y_upper_deviation * -1
        
        
        plt.plot(y_upper_deviation, color="grey", linestyle=":", linewidth=1.5, label="Akzeptierte Abweichung")
        plt.plot(y_lower_deviation, color="grey", linestyle=":", linewidth=1.5)
        
        plt.plot(resids, label="Residuen")
        plt.ylabel("Abweichung in MWh")
        plt.ylim(-50000, 50000)
        plt.title("Residuen")
        
        #Legende einfügen
        handles, labels = plt.gca().get_legend_handles_labels()
        by_label = OrderedDict(zip(labels, handles))
        plt.legend(by_label.values(), by_label.keys(), loc="lower left", bbox_to_anchor=(0,-0.16), ncol=5)
        
        plt.show()
        
    if acfpacf == True:
        
        fig, ax = plt.subplots(1,2)
        
        ax[0].axvline(x=7, linestyle="--", color="lightgrey")
        ax[0].axvline(x=14, linestyle="--", color="lightgrey")
        ax[1].axvline(x=7, linestyle="--", color="lightgrey")
        ax[1].axvline(x=14, linestyle="--", color="lightgrey")
        
        plot_acf(resids, lags=21, ax=ax[0]);
        plot_pacf(resids, lags=21, ax=ax[1]);

#EVALUATE_TRAINING######################################################################################################################################################
def evaluate_training(df_metrics, df_history, ylimmax = 10000):
    
    import matplotlib
    import matplotlib.pyplot as plt
    font = {'size'   : 20}
    matplotlib.rc('font', **font)
    
    from pylab import rcParams
    rcParams["figure.figsize"] = 30,16
    
    print(df_metrics)
    
    print("\n\n")
    
    plt.title("Lernkurve der Verlustfunktion")

    #Verlustfunktion für Training
    plt.plot(df_history["train_loss"], color="blue", linewidth=4, label="Training")
    plt.plot(df_history["1_train_loss"], color="blue", linestyle="--", alpha=0.3)
    plt.plot(df_history["2_train_loss"], color="blue", linestyle="--", alpha=0.3)
    plt.plot(df_history["3_train_loss"], color="blue", linestyle="--", alpha=0.3)
    plt.plot(df_history["4_train_loss"], color="blue", linestyle="--", alpha=0.3)
    plt.plot(df_history["5_train_loss"], color="blue", linestyle="--", alpha=0.3)

    #Verlustfunktion für Validierung
    plt.plot(df_history["validation_loss"], color="red", linewidth=4, label="Validation")
    plt.plot(df_history["1_validation_loss"], color="red", linestyle="--", alpha=0.3)
    plt.plot(df_history["2_validation_loss"], color="red", linestyle="--", alpha=0.3)
    plt.plot(df_history["3_validation_loss"], color="red", linestyle="--", alpha=0.3)
    plt.plot(df_history["4_validation_loss"], color="red", linestyle="--", alpha=0.3)
    plt.plot(df_history["5_validation_loss"], color="red", linestyle="--", alpha=0.3)
    
    plt.ylim(0.00,ylimmax)

    for i in range(0,ylimmax+1,1000):

        plt.axhline(y=i, color="grey", linestyle=":")

    plt.ylabel("Loss (RMSE)")
    plt.xlabel("Epoche")
    
    plt.legend()
    plt.show()
        
#CUSTOM_METRICS_LSTM####################################################################################################################################################
def custom_metrics_lstm(y_test_true, y_scaled_preds_test, y_train_true, y_scaled_preds_train, statistics=True, plot=True, residuals=False, acfpacf=False):
    
    from sklearn import metrics
    import numpy as np
    
    import pandas as pd
    from collections import OrderedDict
    
    from sklearn.preprocessing import MinMaxScaler
    import joblib
    
    import matplotlib
    import matplotlib.pyplot as plt
    font = {'size'   : 20}
    matplotlib.rc('font', **font)
    
    from pylab import rcParams
    rcParams["figure.figsize"] = 30,16
    
    from statsmodels.graphics.tsaplots import plot_acf, plot_pacf
    
    scaler_target = joblib.load("../3-Data Preparation/scaler_endog.save")
    y_preds_test = pd.DataFrame(data=scaler_target.inverse_transform(y_scaled_preds_test.reshape(-1, 1)), columns=["vorhergesagt"], index=pd.date_range('01/01/2021', periods=365, freq='D')).squeeze()
    y_preds_train = pd.DataFrame(data=scaler_target.inverse_transform(y_scaled_preds_train.reshape(-1, 1)), columns=["vorhergesagt"]).squeeze()
    
    resids = y_test_true - y_preds_test
    
    if statistics == True:
        
        df_metrics = pd.DataFrame(index=["R2", "MAE", "MSE", "RMSE", "",  "MAPE"])
        
        df_metrics["Testdaten"] = [
            round(metrics.r2_score(y_test_true, y_preds_test), 2),
            round(metrics.mean_absolute_error(y_test_true, y_preds_test), 0),
            round(metrics.mean_squared_error(y_test_true, y_preds_test), 0),
            round(np.sqrt(metrics.mean_squared_error(y_test_true, y_preds_test)), 0),
            "",
            "" + str(round(metrics.mean_absolute_percentage_error(y_test_true, y_preds_test)*100, 2)) + " %"
        ]
        
        df_metrics["Trainingsdaten"] = [
            round(metrics.r2_score(y_train_true, y_preds_train), 2),
            round(metrics.mean_absolute_error(y_train_true, y_preds_train), 0),
            round(metrics.mean_squared_error(y_train_true, y_preds_train), 0),
            round(np.sqrt(metrics.mean_squared_error(y_train_true, y_preds_train)), 0),
            "",
            "" + str(round(metrics.mean_absolute_percentage_error(y_train_true, y_preds_train)*100, 2)) + " %"
        ]
        
        print(df_metrics)
        
    if plot == True:
    
        for date in y_test_true[y_test_true.index.weekday == 0].index:

            plt.axvline(x=date, ymin=0, ymax=1, color="lightblue", linestyle="--", label="Wochenanfang")
        
        plt.plot(y_test_true, color="blue", label="Wahr");
        plt.plot(y_preds_test, color="red", label="Vorhergesagt");
        plt.title("Wahre und vorhersage Werte")
        plt.ylabel("Stromverbrauch in MWh")
        plt.ylim(100000,235000)
        
        #Legende einfügen
        handles, labels = plt.gca().get_legend_handles_labels()
        by_label = OrderedDict(zip(labels, handles))
        plt.legend(by_label.values(), by_label.keys(), loc="lower left", bbox_to_anchor=(0,-0.16), ncol=5)
        
        plt.show()
    
    if residuals == True:
        
        for date in y_test_true[y_test_true.index.weekday == 0].index:

            plt.axvline(x=date, ymin=0, ymax=1, color="lightblue", linestyle="--", label="Wochenanfang")
        
        y_upper_deviation = y_test_true * 0.022
        y_lower_deviation = y_upper_deviation * -1
        
        
        plt.plot(y_upper_deviation, color="grey", linestyle=":", linewidth=1.5, label="Akzeptierte Abweichung")
        plt.plot(y_lower_deviation, color="grey", linestyle=":", linewidth=1.5)
        
        plt.plot(resids, label="Residuen")
        plt.ylabel("Abweichung in MWh")
        plt.ylim(-50000, 50000)
        plt.title("Residuen")
        
        #Legende einfügen
        handles, labels = plt.gca().get_legend_handles_labels()
        by_label = OrderedDict(zip(labels, handles))
        plt.legend(by_label.values(), by_label.keys(), loc="lower left", bbox_to_anchor=(0,-0.16), ncol=5)
        
        plt.show()
        
    if acfpacf == True:
        
        fig, ax = plt.subplots(1,2)
        
        ax[0].axvline(x=7, linestyle="--", color="lightgrey")
        ax[0].axvline(x=14, linestyle="--", color="lightgrey")
        ax[1].axvline(x=7, linestyle="--", color="lightgrey")
        ax[1].axvline(x=14, linestyle="--", color="lightgrey")
        
        plot_acf(resids, lags=21, ax=ax[0]);
        plot_pacf(resids, lags=21, ax=ax[1]);

#CUSTOM_METRICS#########################################################################################################################################################
def custom_metrics(y_true, y_pred, residuals=False, acfpacf=False, statistics=True, plot=True):
    
    from sklearn import metrics
    import numpy as np
    
    import matplotlib
    import matplotlib.pyplot as plt
    font = {'size'   : 20}
    matplotlib.rc('font', **font)
    
    from pylab import rcParams
    rcParams["figure.figsize"] = 30,16
    
    import pandas as pd
    from collections import OrderedDict
    
    from statsmodels.graphics.tsaplots import plot_acf, plot_pacf
    
    resids = y_true - y_pred
    
    if statistics == True:
    
        df_metrics = pd.DataFrame(index=["R2", "MAE", "MSE", "RMSE", "",  "MAPE"])
        df_metrics["Vorhersage"] = [
            round(metrics.r2_score(y_true, y_pred), 1),
            round(metrics.mean_absolute_error(y_true, y_pred), 1),
            round(metrics.mean_squared_error(y_true, y_pred), 1),
            round(np.sqrt(metrics.mean_squared_error(y_true, y_pred)), 1),
            "",
            "" + str(round(metrics.mean_absolute_percentage_error(y_true, y_pred)*100, 1)) + " %"
        ]
        
        print(df_metrics)
    
    if plot == True:
        
        for date in y_true[y_true.index.weekday == 0].index:

            plt.axvline(x=date, ymin=0, ymax=1, color="lightblue", linestyle="--", label="Wochenanfang")
    
        plt.plot(y_true, color="blue", label="Wahr");
        plt.plot(y_pred, color="orange", label="Vorhergesagt");
        plt.title("Wahre und vorhersage Werte")
        plt.ylabel("Stromverbrauch in MWh")
        plt.ylim(100000,235000)
        
        #Legende einfügen
        handles, labels = plt.gca().get_legend_handles_labels()
        by_label = OrderedDict(zip(labels, handles))
        plt.legend(by_label.values(), by_label.keys(), loc="lower left", bbox_to_anchor=(0,-0.16), ncol=5)
        
        plt.show()
    
    if residuals == True:
    
        for date in y_true[y_true.index.weekday == 0].index:

            plt.axvline(x=date, ymin=0, ymax=1, color="lightblue", linestyle="--", label="Wochenanfang")
        
        y_upper_deviation = y_true * 0.022
        y_lower_deviation = y_upper_deviation * -1
        
        plt.plot(y_upper_deviation, color="grey", linestyle=":", linewidth=1.5, label="Akzeptierte Abweichung")
        plt.plot(y_lower_deviation, color="grey", linestyle=":", linewidth=1.5)
        
        plt.plot(resids, label="Residuen")
        plt.ylabel("Abweichung in MWh")
        plt.ylim(-50000, 50000)
        plt.title("Residuen")
        
        #Legende einfügen
        handles, labels = plt.gca().get_legend_handles_labels()
        by_label = OrderedDict(zip(labels, handles))
        plt.legend(by_label.values(), by_label.keys(), loc="lower left", bbox_to_anchor=(0,-0.16), ncol=5)
        
        plt.show()
        
    if acfpacf == True:
        
        fig, ax = plt.subplots(1,2)
        
        ax[0].axvline(x=7, linestyle="--", color="lightgrey")
        ax[0].axvline(x=14, linestyle="--", color="lightgrey")
        ax[1].axvline(x=7, linestyle="--", color="lightgrey")
        ax[1].axvline(x=14, linestyle="--", color="lightgrey")
        
        plot_acf(resids, lags=21, ax=ax[0]);
        plot_pacf(resids, lags=21, ax=ax[1]);

#TRAIN_TEST_SPLIT#######################################################################################################################################################        
def train_test_split(input_data, test_size, overlap=False):
    
    if test_size >= 1:
        
        split_index = len(input_data) - test_size
        
        train = input_data[0:split_index]
        
        if overlap==True: test = input_data[split_index-1:len(input_data)]
        if overlap==False: test = input_data[split_index:len(input_data)]
            
        return train, test
        
    
    if test_size < 1:
    
        train_size = int(len(input_data) * test_size)

        train = input_data[0:train_size]

        if overlap==True: test = input_data[train_size-1:len(input_data)]
        if overlap==False: test = input_data[train_size:len(input_data)]
    
        return train, test

#Functions for Plotting#################################################################################################################################################
def draw_years(data):
    
    import matplotlib.pyplot as plt
    
    for date in data[data.index.dayofyear == 1].index:

        plt.axvline(x=date, ymin=0, ymax=1, color="grey", linestyle="-.", label="Jahresanfang")

def draw_weeks(data):
    
    import matplotlib.pyplot as plt
    
    for date in data[data["wochentag"] == "Montag"].index:

        plt.axvline(x=date, ymin=0, ymax=1, color="lightblue", linestyle="--", label="Wochenanfang")
        
def draw_holiday(data):
    
    import matplotlib.pyplot as plt
    
    for date in data[data["feiertag"].isna() == False].index:

        plt.axvline(x=date, ymin=0, ymax=1, color="lightgreen", linestyle="-.", label="Feiertag")

#CORRELATION_COEFFICIENTS###############################################################################################################################################
def correlation_coefficients(data_x, data_y):
    
    import scipy
    
    def output(method, correlation, p_value):
        
        print(method, ":")
        
        if p_value <= 0.05: print("p-Wert von", round(p_value, 3), "-> Nullhypothese wird abgelehnt: Die Daten korrelieren mit einem Koeffizienten von", round(correlation, 3))
        if p_value > 0.05: print("p-Wert von", round(p_value, 3), "-> Nullhypothese wird beibehalten: Daten korrelieren nicht")
    
    correlation, p_value = scipy.stats.pearsonr(data_x, data_y)
    output("Pearson", correlation, p_value)
    
    correlation, p_value = scipy.stats.spearmanr(data_x, data_y)
    output("Spearman", correlation, p_value)
    
    correlation, p_value = scipy.stats.kendalltau(data_x, data_y)
    output("Kendall", correlation, p_value)