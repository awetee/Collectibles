import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {DataService} from '../../shared/data.service';
import { Router } from '@angular/router';
import { Collectible } from '../shared/Collectible';

@Component({
    selector: 'collectible-detail',
    styleUrls: ['./collectible-detail.component.css'],
    templateUrl: './collectible-detail.component.html'
})
export class CollectibleDetailComponent implements OnInit {
    private collectibleId: string;
    public collectibleDetails: any = {};
    public collectibleType: any = {};
    public collectibleTypes: any =
        ["First", "Second", "Technology", "Brands", "Books",
        "Architecture", "Art", "Card", "Aphemera", "Clothing",
        "Currency", "Sport", "Music"];

    constructor(public collectibleService: DataService, private route: ActivatedRoute, private router: Router) {
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.collectibleId = params['collectibleId'] || '';

            if (this.collectibleId) {
                this.collectibleService.getById(this.collectibleId)
                    .subscribe(collectibleDetails => {
                        this.collectibleDetails = collectibleDetails;
                        this.collectibleType = collectibleDetails.Type;
                    });
            }
        });
    }

    deleteCollectible(id: string) {
        this.collectibleService.delete(id)
            .subscribe(({name}) => {
                console.log(name);
                this.router.navigate(['/collectible']);
            });
    }

    updateCollectible() {
        this.collectibleService.put(this.collectibleDetails)
            .subscribe(() => {
                this.router.navigate(['/collectible']);
            });
    }

    save() {
        this.collectibleService.post(this.collectibleDetails)
            .subscribe(({name}) => {
                console.log(name);
                this.router.navigate(['/collectible']);
            });
    }
}