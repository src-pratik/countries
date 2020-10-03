import { Injectable } from '@angular/core';
import { HttpRequest, HttpResponse, HttpHandler, HttpEvent, HttpInterceptor, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { delay, mergeMap, materialize, dematerialize } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

let _countrylist = [];
let _countries = [];
let _flags = [];

@Injectable()
export class MockBackendInterceptor implements HttpInterceptor {

    constructor() {

        if (environment.mockBackend.enabled === false)
            return;

        if (_countrylist.length == 0) {
            try {
                var storage = localStorage.getItem('mockdata.countrylist');
                if (storage !== null) {
                    _countrylist = JSON.parse(storage);
                }

            } catch (error) {
                console.error("Unable to load country list." + error);
            }
        }

        if (_countries.length == 0) {
            try {
                var storage = localStorage.getItem('mockdata.countries');
                if (storage !== null) {
                    _countries = JSON.parse(storage);
                }

            } catch (error) {
                console.error("Unable to load countries." + error);
            }
        }

        if (_flags.length == 0) {
            try {
                var storage = localStorage.getItem('mockdata.flags');
                if (storage !== null) {
                    _flags = JSON.parse(storage);
                }

            } catch (error) {
                console.error("Unable to load flags." + error);
            }
        }
    }

    intercept(req: HttpRequest<any>, next: HttpHandler):
        Observable<HttpEvent<any>> {

        /** Pass untouched request through to the next request handler. */
        if (environment.mockBackend.enabled == false)
            return next.handle(req);

        const { url = new URL(req.url).pathname, method, headers, body } = req;

        return of(null)
            .pipe(mergeMap(handleRoute))
            .pipe(materialize()) // call materialize and dematerialize to ensure delay even if an error is thrown (https://github.com/Reactive-Extensions/RxJS/issues/648)
            .pipe(delay(environment.mockBackend.delay))
            .pipe(dematerialize());

        function handleRoute() {
            switch (true) {
                case url.match('api/country/list') && method === 'GET':
                    return getList();
                case url.match('api/country') && method === 'POST':
                    return next.handle(req);
                case url.includes('api/country') && url.length > ('api/country').length && method === 'GET':
                    return getById();
                case url.includes('api/flag') && url.length > ('api/flag').length && method === 'GET':
                    return getFlagById();
                default:
                    // pass through any requests not handled above
                    return next.handle(req);
            }
        }
        function getList() {
            return ok(_countrylist);
        }

        function getById() {
            var idParameter = url.split("/").reverse()[0];
            var country = _countries.find(x => x.id == idParameter);
            return ok(country);
        }

        function ok(body?) {
            return of(new HttpResponse({ status: 200, body }))
        }

        function getFlagById() {
            var idParameter = url.split("/").reverse()[0];
            var flag = _flags.find(x => x.id == idParameter);
            return ok(flag);
        }
    }
}

export const fakeBackendProvider = {
    // use fake backend in place of Http service for backend-less development
    provide: HTTP_INTERCEPTORS,
    useClass: MockBackendInterceptor,
    multi: true
};