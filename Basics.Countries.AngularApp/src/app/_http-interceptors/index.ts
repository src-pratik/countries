import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { MockBackendInterceptor } from '../_common/MockBackend';


/** Http interceptor providers in outside-in order */
export const httpInterceptorProviders = [
    { provide: HTTP_INTERCEPTORS, useClass: MockBackendInterceptor, multi: true },
];