"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var app_component_1 = require("./app.component");
var app_routing_module_1 = require("./app-routing.module");
var auth_service_1 = require("./_services/auth.service");
var auth_guard_1 = require("./_guards/auth.guard");
var oppdrag_service_1 = require("./_services/oppdrag.service");
var temp_service_1 = require("./_services/temp.service");
var data_service_1 = require("./_services/data.service");
var http_1 = require("@angular/http");
// used to create fake backend
var fake_backend_1 = require("./_helpers/fake-backend");
var testing_1 = require("@angular/http/testing");
var http_2 = require("@angular/http");
var login_comonent_1 = require("./login/login.comonent");
var home_module_1 = require("./home/home.module");
var not_found_component_1 = require("./shared/not-found.component");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [platform_browser_1.BrowserModule, home_module_1.HomeModule, forms_1.ReactiveFormsModule, app_routing_module_1.AppRoutingModule, http_1.HttpModule],
        declarations: [app_component_1.AppComponent, login_comonent_1.LoginComponent, not_found_component_1.PageNotFoundComponent],
        providers: [
            auth_guard_1.AuthGuard,
            auth_service_1.AuthenticationService,
            oppdrag_service_1.OppdragService,
            temp_service_1.TempService,
            data_service_1.DataService,
            // providers used to create fake backend
            fake_backend_1.fakeBackendProvider,
            testing_1.MockBackend,
            http_2.BaseRequestOptions
        ],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map