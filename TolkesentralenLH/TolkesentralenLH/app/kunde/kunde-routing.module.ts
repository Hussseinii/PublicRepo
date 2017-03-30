    import { NgModule }              from '@angular/core';
    import { RouterModule, Routes }  from '@angular/router';
    import { KundeComponent }   from './kunde.component';
    
    const appRoutes: Routes = [
      { path: '', component: KundeComponent }
    ];
    @NgModule({
      imports: [
        RouterModule.forChild(appRoutes)
      ],
      exports: [
        RouterModule
      ]
    })
    export class KundeRoutingModule {}