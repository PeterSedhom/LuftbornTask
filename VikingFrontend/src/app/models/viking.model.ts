export enum VikingGender {
  Male = 0,
  Female = 1,
  Other = 2
}

export enum VikingRank {
  Warrior = 0,
  Scout = 1,
  Berserker = 2,
  Chief = 3,
  Seer = 4
}

export interface Viking {
  id?: string;
  name: string;
  age: number;
  gender: VikingGender;
  rank: VikingRank;
}
