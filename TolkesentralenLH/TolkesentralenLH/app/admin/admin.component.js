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
var data_service_1 = require("../_services/data.service");
var AdminComponent = (function () {
    function AdminComponent(dataService) {
        this.dataService = dataService;
    }
    AdminComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.dataService.getData().subscribe(function (data) {
            _this.temp = data;
            _this.element = _this.temp;
            switch (_this.element.element) {
                case 'oppdrag':
                    _this.antallOppdrag = _this.element.nr;
                    break;
                case 'oversettelse':
                    _this.antallOversettelser = _this.element.nr;
                    break;
            }
            _this.sum = _this.getSum();
        });
    };
    AdminComponent.prototype.getSum = function () {
        var sum = 0;
        sum += this.antallOppdrag == null ? 0 : this.antallOppdrag;
        sum += this.antallOversettelser == null ? 0 : this.antallOversettelser;
        return sum == 0 ? "" : "" + sum;
    };
    return AdminComponent;
}());
AdminComponent = __decorate([
    core_1.Component({
        selector: 'admin',
        templateUrl: "./app/admin/admin.component.html"
    }),
    __metadata("design:paramtypes", [data_service_1.DataService])
], AdminComponent);
exports.AdminComponent = AdminComponent;
//# sourceMappingURL=admin.component.js.map