import React, { Component } from 'react';
import { PhoneList } from './PhoneList';

export class Phones extends Component {
    displayName = Phones.name

    render() {
        return (
            <PhoneList apiUrl="/api/phone"/>
        );
    }
}
