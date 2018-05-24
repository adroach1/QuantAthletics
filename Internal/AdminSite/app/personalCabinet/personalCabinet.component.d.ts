import { OnInit } from '@angular/core';
import { Link } from '../usefullLinksService/link';
import { UsefullLinkService } from '../usefullLinksService/usefulllink.service';
export declare class PersonalCabinet implements OnInit {
    private linkService;
    private _usefullLinkService;
    private _linkList;
    readonly LinkList: Link[];
    constructor(linkService: UsefullLinkService);
    ngOnInit(): void;
}
