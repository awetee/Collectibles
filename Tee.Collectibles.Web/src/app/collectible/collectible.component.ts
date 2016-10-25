import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CollectibleService } from './shared/collectible.service';

@Component({
    selector: 'collectible',
    templateUrl: './collectible.component.html',
    styleUrls: ['./collectible.component.css']
})
export class CollectibleComponent {
    constructor(private router: Router, private collectibleService: CollectibleService) {
    }

    //deleteCollectible(id: number) {
    //    this.collectibleService.getById(id)
    //        .subscribe(({name}) => {
    //            console.log(name);
    //            this.router.navigate(['/collectible', id]);
    //        });
    //}
}