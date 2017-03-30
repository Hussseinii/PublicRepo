import { Injectable } from '@angular/core';


@Injectable()
export class TempService {
    object: any;

    setObject(object: any){
        this.object = object;
    }

    getObject(){
        return this.object;
    }
}
