"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var oppdrag_service_1 = require("../_services/oppdrag.service");
var models_1 = require("../_models/models");
var data_service_1 = require("../_services/data.service");
var OversettelseComponent = (function () {
    function OversettelseComponent(oppdragService, dataService) {
        this.oppdragService = oppdragService;
        this.dataService = dataService;
        this.arrayOversettelse = [];
    }
    OversettelseComponent.prototype.ngOnInit = function () {
        var _this = this;
        // get users from secure api end point
        this.oppdragService.getOversettelser()
            .subscribe(function (oppdrag) {
            _this.arrayOversettelse = oppdrag;
            _this.element = new models_1.NavbarElement();
            _this.element.nr = _this.arrayOversettelse.length;
            _this.element.element = 'oversettelse';
            _this.dataService.updateData(_this.element);
        });
    };
    return OversettelseComponent;
}());
OversettelseComponent = __decorate([
    core_1.Component({
        templateUrl: "./app/admin/oversettelse.component.html"
    }),
    __metadata("design:paramtypes", [oppdrag_service_1.OppdragService,
        data_service_1.DataService])
], OversettelseComponent);
exports.OversettelseComponent = OversettelseComponent;
//# sourceMappingURL=oversettelse.component.js.map