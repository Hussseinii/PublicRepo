import { Component, Input } from '@angular/core';

@Component({
  selector: 'admin-navbar',
  templateUrl: 'app/admin/admin-navbar.component.html'
  //template: `<p>test</p>`
})
export class AdminNavbarComponent  { 
    @Input('antall') antall: number;
    @Input('antallOppdrag') antallOppdrag: number;
    @Input('antallOversettelser') antallOversettelser: number;
    @Input('antallKunder') antallKunder: number;
    test: number = 1;

    getSum(){
      this.test++;;
    }
}