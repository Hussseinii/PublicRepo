import { Component, OnInit } from '@angular/core';
import { Oppdrag } from '../_models/models'
import { OppdragService } from '../_services/oppdrag.service'
import { Router, ActivatedRoute, Params } from '@angular/router';
import { TempService} from '../_services/temp.service'
import { DataService } from '../_services/data.service'
import { NavbarElement } from '../_models/models'


@Component({
    templateUrl: "./app/admin/oppdrag.component.html"
})
export class OppdragComponent {
   arrayOppdrag: Oppdrag[] = [];
   index: number; // valgt index i array
   detaljer: boolean;
   count: number;
   element: NavbarElement;

    constructor(
        private dataService: DataService,
        private oppdragService: OppdragService,
        private route: ActivatedRoute,
        private tempService: TempService,
        private router: Router) { }

    ngOnInit() {
        this.count = 77;

        

        // get users from secure api end point
        this.oppdragService.getOppdrag()
            .subscribe(oppdrag => {
                this.arrayOppdrag = oppdrag;
                this.element = new NavbarElement();
                this.element.nr= this.arrayOppdrag.length;
                this.element.element = 'oppdrag';
                this.dataService.updateData(this.element);
            }); 
    }

    /*onUtdel(oppdrag: Oppdrag) {
        this.router.navigate(['/hero', oppdrag.id]);
    }*/
    onUtdel(oppdrag: Oppdrag){ 
        this.tempService.setObject(oppdrag);
        this.router.navigate(['./admin/utdel']);
    }

    visDetaljer(index: number) {
        
        if (this.index != index) {
            this.detaljer = true;
            this.index = index;
            return;
        }
        this.index = index;
        this.detaljer ? this.detaljer = false : this.detaljer = true;
    }
    
}