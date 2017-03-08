export class NavbarElement {
    nr: number;
    element: string;
}

export class Oppdrag {
    id: number;
    dato: string;

    sted: string;
    tid: string;

    type: string;
    fraspraak: string;
    tilspraak: string;
    email: string;
    tlf: string;

    fornavn: string;
    etternavn: string;
    adresse: string;
    postnr: string;
    poststed: string;

    melding: string;
    firma: string;
}

export class Tolk {
    id: number;

    spraak: string;
    email: string;
    tlf: string;

    fornavn: string;
    etternavn: string;
    adresse: string;
    postnr: string;
    poststed: string;

    valgt: boolean;
}

export class Oversettelse {
    id: number;

    spraak: string;
    email: string;
    tlf: string;

    fornavn: string;
    etternavn: string;
    adresse: string;
    postnr: string;
    poststed: string;

    valgt: boolean;
}

export class Kunde {
    id: number;

    email: string;
    tlf: string;

    fornavn: string;
    etternavn: string;
    adresse: string;
    postnr: string;
    poststed: string;
}