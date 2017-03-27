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
var router_1 = require("@angular/router");
var temp_service_1 = require("../_services/temp.service");
var data_service_1 = require("../_services/data.service");
var models_1 = require("../_models/models");
var OppdragComponent = (function () {
    function OppdragComponent(dataService, oppdragService, route, tempService, router) {
        this.dataService = dataService;
        this.oppdragService = oppdragService;
        this.route = route;
        this.tempService = tempService;
        this.router = router;
        this.arrayOppdrag = [];
    }
    OppdragComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.count = 77;
        // get users from secure api end point
        this.oppdragService.getOppdrag()
            .subscribe(function (oppdrag) {
            _this.arrayOppdrag = oppdrag;
            _this.element = new models_1.NavbarElement();
            _this.element.nr = _this.arrayOppdrag.length;
            _this.element.element = 'oppdrag';
            _this.dataService.updateData(_this.element);
        });
    };
    /*onUtdel(oppdrag: Oppdrag) {
        this.router.navigate(['/hero', oppdrag.id]);
    }*/
    OppdragComponent.prototype.onUtdel = function (oppdrag) {
        this.tempService.setObject(oppdrag);
        this.router.navigate(['./admin/utdel']);
    };
    OppdragComponent.prototype.visDetaljer = function (index) {
        if (this.index != index) {
            this.detaljer = true;
            this.index = index;
            return;
        }
        this.index = index;
        this.detaljer ? this.detaljer = false : this.detaljer = true;
    };
    return OppdragComponent;
}());
OppdragComponent = __decorate([
    core_1.Component({
        templateUrl: "./app/admin/oppdrag.component.html"
    }),
    __metadata("design:paramtypes", [data_service_1.DataService,
        oppdrag_service_1.OppdragService,
        router_1.ActivatedRoute,
        temp_service_1.TempService,
        router_1.Router])
], OppdragComponent);
exports.OppdragComponent = OppdragComponent;
//# sourceMappingURL=oppdrag.component.js.map