import {Component, OnInit} from '@angular/core';
import {DataService} from '../../shared/data.service';
import {Observable} from 'rxjs/Observable';
import {ActivatedRoute} from '@angular/router';
import { Router } from '@angular/router';

@Component({
    selector: 'collectible-list',
    styleUrls: ['./collectible-list.component.css'],
    templateUrl: './collectible-list.component.html'
})
export class CollectibleListComponent implements OnInit {
    collectibles: Observable<any>;

    constructor(public dataService: DataService, private router: Router) {
    }

    ngOnInit() {
        this.collectibles = this.dataService.getAll();
    }

    onDelete(Id: string){
        var collectibleObject = this.collectibles.filter(function( collectible ) {
                return collectible.Id == Id;
            });

        var confirmed = confirm("Are you sure you will like to delete")

        if(confirm){
            this.dataService.delete(Id).subscribe((result) => {
                this.collectibles = this.collectibles.filter(function( collectible ) {
                    return collectible.Id !== result;
                });
                this.router.navigate(['/collectible']);
            });
        }
    }
}