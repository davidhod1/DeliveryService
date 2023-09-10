import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, delay, finalize, identity } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoaderManagerService } from '../_services/loader-manager.service';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private loaderManagerService: LoaderManagerService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.loaderManagerService.run();

    return next.handle(request).pipe(
      (environment.production ? identity : delay(500)),
      finalize(() => {
        this.loaderManagerService.idle();
      })
    )
  }
}