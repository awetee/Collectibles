import {NgModule} from '@angular/core'
import {RouterModule} from "@angular/router";
import {rootRouterConfig} from "./app.routes";
import {AppComponent} from "./app.component";
import {FormsModule} from "@angular/forms";
import {BrowserModule} from "@angular/platform-browser";
import {HttpModule} from "@angular/http";
import {LocationStrategy, HashLocationStrategy} from '@angular/common';

import {CollectibleComponent} from './collectible/collectible.component';
import {CollectibleListComponent} from './collectible/collectible-list/collectible-list.component';
import {CollectibleDetailComponent} from './collectible/collectible-detail/collectible-detail.component';
import {CollectibleFormComponent} from './collectible/collectible-form/collectible-form.component';
import {DataService} from './shared/data.service';

@NgModule({
    declarations: [AppComponent, CollectibleComponent, CollectibleListComponent, CollectibleDetailComponent, CollectibleFormComponent],
    imports: [BrowserModule, FormsModule, HttpModule, RouterModule.forRoot(rootRouterConfig)],
    providers: [DataService, { provide: LocationStrategy, useClass: HashLocationStrategy }],
    bootstrap: [AppComponent]
})
export class AppModule {
}