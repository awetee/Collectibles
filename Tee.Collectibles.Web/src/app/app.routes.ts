import {Routes} from '@angular/router';
import {CollectibleComponent} from './collectible/collectible.component';
import {CollectibleListComponent} from './collectible/collectible-list/collectible-list.component';
import {CollectibleDetailComponent} from './collectible/collectible-detail/collectible-detail.component';

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: 'collectible', pathMatch: 'full' },
    {
        path: 'collectible', component: CollectibleComponent,
        children: [
            { path: '', component: CollectibleListComponent },
            { path: ':collectibleId', component: CollectibleDetailComponent }]
    }
];