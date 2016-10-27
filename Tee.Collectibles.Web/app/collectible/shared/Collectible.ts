export class Collectible {
    constructor(
    public Id: number = 0,
    public Title: string = '',
    public Description: string = '',
    public IsShared: boolean = false,
    public TypeId?: number
        ){}
}