import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class LoaderManagerService {
  requestCount = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  run(){
    this.requestCount++;
    this.spinnerService.show(undefined, {
      type: 'ball-spin-clockwise',
      bdColor: 'rgb(255, 255, 255, 0)',
      color: '#333333',
      size: 'medium'
    })
  }

  idle(){
    this.requestCount--;
    if(this.requestCount <= 0){
      this.requestCount = 0;
      this.spinnerService.hide();
    }
  }
}
