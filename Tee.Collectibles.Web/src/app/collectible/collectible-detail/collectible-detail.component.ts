import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {CollectibleService} from '../shared/collectible.service';

@Component({
    selector: 'collectible-detail',
    styleUrls: ['./collectible-detail.component.css'],
    templateUrl: './collectible-detail.component.html'
})
export class CollectibleDetailComponent implements OnInit {
    private collectibleId: string;
    public collectibleDetails: any = {};

    constructor(public collectibleService: CollectibleService, private route: ActivatedRoute) {
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.collectibleId = params['collectibleId'] || '';

            if (this.collectibleId) {
                this.collectibleService.getById(this.collectibleId)
                    .subscribe(collectibleDetails => {
                        this.collectibleDetails = collectibleDetails;
                    });
            }
        });
    }
}