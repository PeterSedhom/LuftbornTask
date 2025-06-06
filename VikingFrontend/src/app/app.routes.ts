import { Routes } from '@angular/router';
import { VikingComponent } from './components/viking/viking';

export const routes: Routes = [
  { path: 'vikings', component: VikingComponent },
  { path: '', redirectTo: '/vikings', pathMatch: 'full' as const }
];