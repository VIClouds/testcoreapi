import React, { Component } from 'react';

export class PhoneForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = { name: "", price: 0 };

        this.onSubmit = this.onSubmit.bind(this);
        this.onNameChange = this.onNameChange.bind(this);
        this.onPriceChange = this.onPriceChange.bind(this);
    }
    onNameChange(e) {
        this.setState({ name: e.target.value });
    }
    onPriceChange(e) {
        this.setState({ price: e.target.value });
    }
    onSubmit(e) {
        e.preventDefault();
        var phoneName = this.state.name.trim();
        var phonePrice = this.state.price;
        if (!phoneName || phonePrice <= 0) {
            return;
        }

        this.props.onPhoneSubmit({ name: phoneName, price: phonePrice });
        //this.setState({ name: "", price: 0 });
    }
    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <p>
                    <input type="text"
                        placeholder="Модель телефона"
                        value={this.state.name}
                        onChange={this.onNameChange} />
                </p>
                <p>
                    <input type="number"
                        placeholder="Цена"
                        value={this.state.price}
                        onChange={this.onPriceChange} />
                </p>
                <input type="submit" value="Сохранить" />
            </form>
        );
    }
}