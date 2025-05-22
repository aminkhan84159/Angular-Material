import { Routes } from '@angular/router';
import { ProductComponent } from './Components/product/product.component';

export const routes: Routes = [
    {
        path: '',
        component: ProductComponent
    },
    {
        path: 'viewProduct/:id',
        loadComponent:() => import('./Components/view-product/view-product.component').then(x => x.ViewProductComponent)
    }
];
