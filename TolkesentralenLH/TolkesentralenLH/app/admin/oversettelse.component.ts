import { Component, OnInit } from '@angular/core';
import { Oppdrag } from '../_models/models'
import { OppdragService } from '../_services/oppdrag.service'
import { NavbarElement } from '../_models/models'
import { DataService } from '../_services/data.service'


@Component({
    templateUrl: "./app/admin/oversettelse.component.html"
})
export class OversettelseComponent {
   arrayOversettelse: Oppdrag[] = [];
   element: NavbarElement;

    constructor(
        private oppdragService: OppdragService,
        private dataService: DataService) { }

    ngOnInit() {

        // get users from secure api end point
        this.oppdragService.getOversettelser()
            .subscribe(oppdrag => {
                this.arrayOversettelse = oppdrag;
                this.element = new NavbarElement();
                this.element.nr= this.arrayOversettelse.length;
                this.element.element = 'oversettelse';
                this.dataService.updateData(this.element);
            });
    }
    
}