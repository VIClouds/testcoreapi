import React, { Component } from 'react';

export class Phone extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.phone };
        this.onClick = this.onClick.bind(this);
    }
    onClick(e) {
        this.props.onRemove(this.state.data);
    }
    render() {
        return (<div>
            <p><b>{this.state.data.name}</b></p>
            <p>Цена {this.state.data.price}</p>
            <p><button onClick={this.onClick}>Удалить</button></p>
        </div>
        );
    }
}