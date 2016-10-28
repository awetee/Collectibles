/// <referemce path="../../../typings/index.d.ts" />
import { CollectibleListComponent } from './collectible-list.component';
import {DataService} from '../../shared/data.service';
import { Router } from '@angular/router';

import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By }              from '@angular/platform-browser';
import { DebugElement }    from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Response } from '@angular/http';


var sut: CollectibleListComponent,
        dataService: DataService,
        router: Router;

let fixture: ComponentFixture<CollectibleListComponent>;
let de:      DebugElement;
let el:      HTMLElement;

// class mockDataService extends DataService{
//    delete(id: string) : Observable<Response>{
//        return Observable.of(new Object());
//    } 
// }

let dataServiceStub: any = {
    delete: () => {}
};

describe('Collectible List Component', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
                declarations: [ CollectibleListComponent ],
                providers:    [ {provide: DataService, useValue: dataServiceStub } ]
            }).compileComponents().then(() => {
                fixture = TestBed.createComponent(CollectibleListComponent);
                sut = fixture.componentInstance;

                dataService = TestBed.get(DataService);
                router = TestBed.get(Router);
            });
    });       

    describe('onDelete', () => {
        it('should call delete', () => {
            (<jasmine.Spy>(dataService.delete)).and.callFake(() => {})
            sut.onDelete('');
            expect(dataService.delete).toHaveBeenCalledTimes(1);
        });
    });

    it('should be true', () => {
        expect(true).toBe(true);
    });


});