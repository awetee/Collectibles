export class Collectible {
    constructor(
    public Id: number,
    public Title: string,
    public Description: string,
    public IsShared: boolean,
    public TypeId: number
        ){}
}