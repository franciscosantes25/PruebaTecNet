import { Routes } from '@angular/router';

export const routes: Routes = [   
    {
        path: 'home',
        loadChildren: () => import('./main/home/home.routes').then(x => x.HOME_ROUTES)
    },
];