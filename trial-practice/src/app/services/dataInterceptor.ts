import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { DataService } from "./data.service";

@Injectable()
export class DataInterceptor implements HttpInterceptor {
// ****************************intercept is a hook method for interface HttpInterceptor in angular4 by diksha***************************************************************************************************
   intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
       debugger;
        if (!req.headers.has('Content-Type')) {
            req = req.clone({ headers: req.headers.set('Content-Type', 'application/json') });
        }

        req = req.clone({ headers: req.headers.set('Accept', 'application/json') });
        console.log(JSON.stringify(req.headers));
        return next.handle(req);
    }

}