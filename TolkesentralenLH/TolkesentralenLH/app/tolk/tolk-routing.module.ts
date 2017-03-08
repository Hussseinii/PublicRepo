    import { NgModule }              from '@angular/core';
    import { RouterModule, Routes }  from '@angular/router';
    import { TolkComponent }   from './tolk.component';
    
    const appRoutes: Routes = [
      { path: '', component: TolkComponent }
    ];
    @NgModule({
      imports: [
        RouterModule.forChild(appRoutes)
      ],
      exports: [
        RouterModule
      ]
    })
    export class TolkRoutingModule {}