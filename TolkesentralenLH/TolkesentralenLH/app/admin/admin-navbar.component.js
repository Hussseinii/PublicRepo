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
var AdminNavbarComponent = (function () {
    function AdminNavbarComponent() {
        this.test = 1;
    }
    AdminNavbarComponent.prototype.getSum = function () {
        this.test++;
        ;
    };
    return AdminNavbarComponent;
}());
__decorate([
    core_1.Input('antall'),
    __metadata("design:type", Number)
], AdminNavbarComponent.prototype, "antall", void 0);
__decorate([
    core_1.Input('antallOppdrag'),
    __metadata("design:type", Number)
], AdminNavbarComponent.prototype, "antallOppdrag", void 0);
__decorate([
    core_1.Input('antallOversettelser'),
    __metadata("design:type", Number)
], AdminNavbarComponent.prototype, "antallOversettelser", void 0);
__decorate([
    core_1.Input('antallKunder'),
    __metadata("design:type", Number)
], AdminNavbarComponent.prototype, "antallKunder", void 0);
AdminNavbarComponent = __decorate([
    core_1.Component({
        selector: 'admin-navbar',
        templateUrl: 'app/admin/admin-navbar.component.html'
        //template: `<p>test</p>`
    })
], AdminNavbarComponent);
exports.AdminNavbarComponent = AdminNavbarComponent;
//# sourceMappingURL=admin-navbar.component.js.map