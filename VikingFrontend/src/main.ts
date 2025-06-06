   import { bootstrapApplication } from '@angular/platform-browser';
   import { App } from './app/app';
   import { provideRouter } from '@angular/router';
   import { routes } from './app/app.routes';
   import { provideHttpClient } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { importProvidersFrom } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';

   bootstrapApplication(App, {
     providers: [
        provideRouter(routes),
        provideHttpClient(),
        provideAnimations(), 
          importProvidersFrom(
          ToastrModule.forRoot({
            positionClass: 'toast-top-right',
            timeOut: 3000,
            preventDuplicates: true
      })
    )
     ]
   })
   .catch(err => console.error(err));