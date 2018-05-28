import App from "./app-module";
import appTemplate from "./app.html";
import "./components";
import "./services";
import { getRating } from "./services/apiService";
import "./style/base.scss";

export const AppCtrl = function () {
}

export const AppComponent =  {
    template: appTemplate,
    controller: AppCtrl,
    bindings: { 
    },
};

App.component("app", AppComponent);
