import React from 'react';

class NumberInput extends React.Component {
    constructor(props) {
        super(props);
        this.state = { number: '', name: '' };

        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleNumberChange = this.handleNumberChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleNameChange(event) {
        this.setState({ name: event.target.value });
    }

    handleNumberChange(event) {
        this.setState({ number: event.target.value });
    }

    handleSubmit(event) {
        event.preventDefault();
        this.props.onSetUserDetails(this.state);
    }

    render() {
        return (
            <div className="number-converter__form-container">
                <form onSubmit={this.handleSubmit}>
                    <div className="number-converter__input-container">
                        <input className="number-converter__input number-converter__input--name" placeholder="Name" required type="text" value={this.state.name} onChange={this.handleNameChange} />
                        <input className="number-converter__input number-converter__input--number" placeholder="Number" required type="number" max="999999999.99" min="0" value={this.state.number} onChange={this.handleNumberChange} />
                        <input className="number-converter__submit" type="submit" value="Convert" />
                    </div>
                </form>
            </div>
        )
    }
}

export default NumberInput;