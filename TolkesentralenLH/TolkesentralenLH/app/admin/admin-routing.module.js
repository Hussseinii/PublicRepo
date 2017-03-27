"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var admin_component_1 = require("./admin.component");
var auth_guard_1 = require("../_guards/auth.guard");
var oppdrag_component_1 = require("./oppdrag.component");
var oversettelse_component_1 = require("./oversettelse.component");
var utdel_component_1 = require("./utdel.component");
var appRoutes = [
    {
        path: '',
        component: admin_component_1.AdminComponent,
        canActivate: [auth_guard_1.AuthGuard],
        children: [
            {
                path: '',
                children: [
                    { path: 'utdel', component: utdel_component_1.UtdelComponent },
                    { path: 'oversettelse', component: oversettelse_component_1.OversettelseComponent },
                    { path: 'oppdrag', component: oppdrag_component_1.OppdragComponent },
                    { path: '', component: oppdrag_component_1.OppdragComponent }
                ]
            }
        ]
    }
];
var AdminRoutingModule = (function () {
    function AdminRoutingModule() {
    }
    return AdminRoutingModule;
}());
AdminRoutingModule = __decorate([
    core_1.NgModule({
        imports: [
            router_1.RouterModule.forChild(appRoutes)
        ],
        exports: [
            router_1.RouterModule
        ]
    })
], AdminRoutingModule);
exports.AdminRoutingModule = AdminRoutingModule;
//# sourceMappingURL=admin-routing.module.js.map