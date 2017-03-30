import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs/Subject';


@Injectable()
export class DataService {
    private dataObs$ = new Subject();


    getData() {
        console.log("serv -> get");
        return this.dataObs$;
    }

    updateData(data: any) {
        console.log("serv -> update");
        this.dataObs$.next(data);
    }
}